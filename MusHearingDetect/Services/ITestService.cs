using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusHearingDetect.Services
{
    public interface ITestService
    {
        byte[] GetAudioArray(IFormFile file);
        bool ProcessRecording(byte[] audioArray, int baseFreq);
        //void AddAnswerToDatabase(IFormFile file);
    }
}
