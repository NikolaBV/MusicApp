using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MusicApp
{
    public class Player
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwdCallBack);
        public void Open(string file)
        {
            string format = @"open ""{0}"" type MPEGVideo alias MediaFile";
            string command = string.Format(format,file);
            mciSendString(command,null,0,0);
        }
        public void Play()
        {
            string command = "play Mediafile";
            mciSendString(command, null, 0, 0);

        }
        public void Stop()
        {
            string command = "stop Mediafile";
            mciSendString(command, null, 0, 0);

        }
    }
}
