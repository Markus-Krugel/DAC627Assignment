using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAC627_Project
{
    public enum AssetType
    {
        _2DArt,         //.png/.jpg
        _ConceptArt,    //.png/.jpg
        _2DAnimation,   //.gif
        _3DModel,       //.fbx/.obj/.mb/.ma/.max
        _3DAnimation,   //.fbx/.obj/.mb/.ma/.max
        _Audio,          //.wav/.mp3
        _NULL
    };

    public enum PegiRating
    {
        _3,
        _7,
        _12,
        _16,
        _18
    }

    public enum UserType
    {
        Null,
        Reviewer,
        Developer
    }

    public enum UserStatus
    {
        Null,
        Offline,
        Online
    }

    public enum ProjectTag
    {
        Null,
        Research,
        Software,
        Game
    }

    public enum ProjectStatus
    {
        Null,
        Completed,
        Planning,
        In_Development
    }

    public enum AssetStatus
    {
        Null,
        Completed,
        Planning,
        In_Development
    }

    public enum ProjectType
    {
        Null,
        Research,
        Software,
        Game
    }
}
