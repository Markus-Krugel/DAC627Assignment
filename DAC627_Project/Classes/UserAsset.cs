using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAC627_Project
{
    public class UserAsset
    {
        public enum AssetType
        {
            _2DArt,         //.png/.jpg
            _ConceptArt,    //.png/.jpg
            _2DAnimation,   //.gif
            _3DModel,       //.fbx/.obj/.mb/.ma/.max
            _3DAnimation,   //.fbx/.obj/.mb/.ma/.max
            _Audio          //.wav/.mp3
        };

        public enum PegiRating
        {
            _3,
            _7,
            _12,
            _16,
            _18
        }

        private UsersAccounts.UserData _author;
        private string _assetTitle;
        private AssetType _assetType;
        private string _softwareUsed;
        private PegiRating _pegiRating;
        private string _assetStatus;
        private string _notes;
        private List<string> _picturesPath; //First element is thumbnail
        private string _assetPath;

        public UserAsset(UsersAccounts.UserData author)
        {
            _author = author;
        }

        //Set Functions
        public void SetAssetTitle(string assetTitle)
        {
            _assetTitle = assetTitle;
        }

        public void SetAssetType(AssetType assetType)
        {
            _assetType = assetType;
        }

        public void SetSoftwareUsed(string softwareUsed)
        {
            _softwareUsed = softwareUsed;
        }

        public void SetPegiRating(PegiRating pegiRating)
        {
            _pegiRating = pegiRating;
        }

        public void SetAssetStatus(string assetStatus)
        {
            _assetStatus = assetStatus;
        }

        public void SetNotes(string notes)
        {
            _notes = notes;
        }

        public void SetAssetPath(string assetPath)
        {
            _assetPath = assetPath;
        }


        //Get Functions
        public string GetAssetTitle()
        {
            return _assetTitle;
        }

        public UsersAccounts.UserData GetAuthor()
        {
            return _author;
        }

        public List<string> GetPicturesPath() //Element 0 is the thumbail
        {
            return _picturesPath;
        }

        public string GetAssetPath() 
        {
            return _assetPath;
        }

        public AssetType GetAssetType()
        {
            return _assetType;
        }

        public string GetSoftwareUsed()
        {
           return _softwareUsed;
        }

        public PegiRating GetPegiRating()
        {
            return _pegiRating;
        }

        public string GetAssetStatus()
        {
            return _assetStatus;
        }

        public string GetNotes()
        {
            return _notes;
        }

        //Picture Functions
        public void AddPictureToGallery(string picturePath)
        {
            _picturesPath.Add(picturePath);
        }

        public void SetThumbnailPicture(string picturePath)
        {
            _picturesPath[0] = picturePath;
        }
    }
}
