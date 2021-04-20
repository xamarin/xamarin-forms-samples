using System;
using Urho;

namespace MonkeySee
{
    public class MonkeyDo : Application
    {
        // For the orientation of the monkey
        Node cameraNode;
        Node monkeyNode;
        Matrix4 cameraTransform;
        Quaternion orientation = Quaternion.Identity;

        // For the rotation of the monkey head
        static readonly Quaternion qSittingUp = Quaternion.FromAxisAngle(new Vector3(1, 0, 0), 90);

        // For the flapping of the monkey arms
        const float PERIOD = 0.25f;     // seconds
        const float MAXAMP = 45;        // degrees
        Quaternion rightArmRotationBase;
        Quaternion leftArmRotationBase;
        Quaternion rightLegRotationBase;
        Quaternion leftLegRotationBase;
        float amplitude = 0;
        float phaseAngle = 0;

        public MonkeyDo(ApplicationOptions options = null) : base(options)
        {
        }

        public Quaternion Orientation
        {
            set
            {
                orientation = value;

                // First calculate the camera rotation based on the device orientation
                orientation.ToAxisAngle(out Vector3 axis, out float angle);
                Matrix4 rotatedCameraTransform = Matrix4.Mult(cameraTransform, 
                                                              Matrix4.CreateFromAxisAngle(axis, -angle));
                cameraNode.SetTransform(To3x4(rotatedCameraTransform));

                // Next tackle the head rotation so it tracks the viewer (somewhat)
                Vector3 monkeyForward = new Vector3(0, 0, -1);
                Vector3 viewForward = Vector3.TransformVector(monkeyForward, rotatedCameraTransform);
                Vector3 crossProduct = Vector3.Cross(monkeyForward, viewForward);

                // Swap some components for the difference in head-bone coordinates
                Vector3 swivelAxis = new Vector3(-crossProduct.Y, 0, crossProduct.X);
                swivelAxis.Normalize();

                float angleBetween = MathHelper.RadiansToDegrees(Vector3.CalculateAngle(monkeyForward, viewForward));

                // Now calculate the swivel angle
                const float FOLLOW = 30;    // degrees for head swivel
                const float IGNORE = 45;    // degrees for head swivel
                const float MAXAMP = 10;    // degrees for arm flap

                float swivelAngle = 0;
                amplitude = 0;

                if (angleBetween > IGNORE)
                {
                    // swivelAngle and amplitude set as above
                }
                else if (angleBetween >= FOLLOW)
                {
                    swivelAngle = FOLLOW / (IGNORE - FOLLOW) * (IGNORE - angleBetween);
                }
                else // angleBetween between 0 and FOLLOW
                {
                    swivelAngle = angleBetween;

                    // Let's slip in here the amplitude of the arm flapping
                    amplitude = MAXAMP * (FOLLOW - angleBetween) / FOLLOW;
                }

                // Calculate the head rotation (FromAxisAngle takes angle in degrees)
                Quaternion headRotation = Quaternion.FromAxisAngle(swivelAxis, -swivelAngle);

                // Rotate the head
                monkeyNode.GetChild("head", true).Rotation = headRotation;
            }
            get
            {
                return orientation;
            }
        }

        protected override void Start()
        {
            base.Start();

            // Create Scene and stuff
            Scene scene = new Scene();
            Octree octree = scene.CreateComponent<Octree>();
            Zone zone = scene.CreateComponent<Zone>();
            zone.AmbientColor = new Color(0.75f, 0.75f, 0.75f);

            // Create the root note
            Node rootNode = scene.CreateChild();
            rootNode.Position = new Vector3(0, 0, 0);

            // Create a light node
            Node lightNode = rootNode.CreateChild();
            Light light = lightNode.CreateComponent<Light>();
            light.Color = new Color(0.75f, 0.75f, 0.75f);
            light.LightType = LightType.Directional;
            lightNode.SetDirection(new Vector3(2, -3, -1));

            // Create the camera
            cameraNode = scene.CreateChild();
            Camera camera = cameraNode.CreateComponent<Camera>();

            // Set camera Position and Direction above the monkey pointing down
            cameraNode.Position = new Vector3(0, 12, 0);
            cameraNode.SetDirection(new Vector3(0, 0, 0) - cameraNode.Position);

            // Save the camera transform resulting from that configuration
            cameraTransform = From3x4(cameraNode.Transform);

            monkeyNode = rootNode.CreateChild("monkeyNode");
            AnimatedModel monkey = monkeyNode.CreateComponent<AnimatedModel>();

            // Xamarin monkey model created by Vic Wang at http://vidavic.weebly.com
            monkey.Model = ResourceCache.GetModel("monkey1.mdl");
            monkey.SetMaterial(ResourceCache.GetMaterial("Materials/phong1.xml"));

            // Move the monkey down a bit so it's centered on the origin
            monkeyNode.Translate(new Vector3(0, -3, 0));

            // Get the initial rotations of the arm bones
            rightArmRotationBase = monkeyNode.GetChild("arm2", true).Rotation;
            leftArmRotationBase = monkeyNode.GetChild("arm6", true).Rotation;

            // And the leg bones
            rightLegRotationBase = monkeyNode.GetChild("leg1", true).Rotation;
            leftLegRotationBase = monkeyNode.GetChild("leg5", true).Rotation;

            // Set up the Viewport
            Viewport viewport = new Viewport(Context, scene, camera, null);
            Renderer.SetViewport(0, viewport);
            viewport.SetClearColor(new Color(0.88f, 0.88f, 0.88f));
        }

        // Matrix conversion methods
        static Matrix3x4 To3x4(Matrix4 m)
        {
            return new Matrix3x4(m.M11, m.M21, m.M31, m.M41,
                                 m.M12, m.M22, m.M32, m.M42,
                                 m.M13, m.M23, m.M33, m.M43);
        }

        static Matrix4 From3x4(Matrix3x4 m)
        {
            return new Matrix4(m.m00, m.m10, m.m20, 0,
                               m.m01, m.m11, m.m21, 0,
                               m.m02, m.m12, m.m22, 0,
                               m.m03, m.m13, m.m23, 1);
        }
        
        protected override void OnUpdate(float timeStep)
        {
            base.OnUpdate(timeStep);

            // Arm-flapping logic
            phaseAngle += MathHelper.TwoPi * timeStep / PERIOD;
            phaseAngle %= MathHelper.TwoPi;

            float angle = amplitude * (float)Math.Sin(phaseAngle);
            Quaternion rotation = Quaternion.FromAxisAngle(new Vector3(0, 0, 1), angle);

            monkeyNode.GetChild("arm2", true).Rotation = rightArmRotationBase * rotation;
            monkeyNode.GetChild("arm6", true).Rotation = leftArmRotationBase * rotation;

            // Hack existing values a bit for the legs
            angle = 1.5f * amplitude * (float)Math.Sin(phaseAngle + MathHelper.PiOver2);
            rotation = Quaternion.FromAxisAngle(new Vector3(0, 0, 1), angle);
            monkeyNode.GetChild("leg1", true).Rotation = rightLegRotationBase * rotation;

            rotation = Quaternion.FromAxisAngle(new Vector3(0, 0, 1), -angle);
            monkeyNode.GetChild("leg5", true).Rotation = leftLegRotationBase * rotation;
        }
    }
}
