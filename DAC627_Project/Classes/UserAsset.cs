using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAC627_Project
{
    public class UserAsset
    {
        
        private UsersAccounts.UserData _author;
        private string _assetTitle;
        private AssetType _assetType;
        private string _softwareUsed;
        private PegiRating _pegiRating;
        private AssetStatus _assetStatus;
        private string _notes;
        private List<string> _picturesPath = new List<string>(); //First element is thumbnail
        private string _thumbNailPicture;
        private string _assetPath;
        private int _id;
        private string _tags;

        public UserAsset(UsersAccounts.UserData author)
        {
            _author = author;
        }

        public UserAsset(int id, string assetName, string notes, UsersAccounts.UserData author, AssetType assetType, AssetStatus assetStatus  ,string softwareUsed, string assetPath, PegiRating pegiRating, string tags, string thumbnail = null, string galleryOne = null, string galleryTwo = null, string galleryThree = null, string galleryFour = null, string galleryFive = null)
        {
            _author = author;
            _id = id;
            _assetTitle = assetName;
            _notes = notes;
            _assetType = assetType;
            _assetStatus = assetStatus;
            _softwareUsed = softwareUsed;
            _assetPath = assetPath;
            _pegiRating = pegiRating;
            _tags = tags;
            _thumbNailPicture = thumbnail;
            _picturesPath.Add(galleryOne);
            _picturesPath.Add(galleryTwo);
            _picturesPath.Add(galleryThree);
            _picturesPath.Add(galleryFour);
            _picturesPath.Add(galleryFive);
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

        public void SetAssetStatus(AssetStatus assetStatus)
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

        public AssetStatus GetAssetStatus()
        {
            return _assetStatus;
        }

        public string GetNotes()
        {
            return _notes;
        }

        public int GetID()
        {
            return _id;
        }

        //Picture Functions
        public void AddPictureToGallery(string picturePath)
        {
            _picturesPath.Add(picturePath);
        }

        public void SetPicturesPath(List<string> picturesPaths) //Element 0 is the thumbail
        {
            _picturesPath = picturesPaths;
        }

        public string GetThumbNail()
        {
            return _thumbNailPicture;
        }

        public void SetThumbNail(string thumbNail)
        {
            _thumbNailPicture = thumbNail;
        }
    }
}
