using System;
using System.Threading.Tasks;

namespace PiLiveRecorder.Services
{
    public interface IRecordingEngine
    {
        Task Record();
        Task Play();
        Task Stop();
    }
}