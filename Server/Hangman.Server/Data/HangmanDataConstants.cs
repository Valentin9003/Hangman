using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Server.Data
{
    public class HangmanDataConstants
    {
        public const int WordContentMaxLength = 200;

        public const int LevelDifficultyMinRangeValue = 200;

        public const int LevelDifficultyMaxRangeValue = 200;

        public const int ProgressLevelMinRangeValue = 1;

        public const int ProgressLevelMaxRangeValue = 6;

        public const int SuffererMaxLength = 10 * 10 * 1024;

        public const string VictimPicturesWebRootFolderNamePathTemplate = "/victimPictures/{i}.png";
    }
}
