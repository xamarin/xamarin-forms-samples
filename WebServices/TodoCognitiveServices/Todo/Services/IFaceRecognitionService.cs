using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    public interface IFaceRecognitionService
    {
		Task<Face[]> DetectAsync(Stream imageStream, bool returnFaceId, bool returnFaceLandmarks, IEnumerable<FaceAttributeType> returnFaceAttributes);
    }
}
