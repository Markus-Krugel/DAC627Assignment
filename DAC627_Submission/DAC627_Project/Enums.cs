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
        _Null
    };

    public enum PegiRating
    {
        _3,
        _7,
        _12,
        _16,
        _18,
        _Null
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
        In_Development,
        Planning
    }

    public enum AssetStatus
    {
        Null,
        Completed,
        In_Development,
        Planning,
    }

    public enum ProjectType
    {
        Null,
        Research,
        Software,
        Game
    }

    enum MessageType
    {
        Request,
        Message,
        Invite
    }
}
