using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TodoCognitive.Models;

namespace TodoCognitive.Services
{
    public interface IFaceRecognitionService
    {
		Task<Face[]> DetectAsync(Stream imageStream, bool returnFaceId, bool returnFaceLandmarks, IEnumerable<FaceAttributeType> returnFaceAttributes);
    }
}
