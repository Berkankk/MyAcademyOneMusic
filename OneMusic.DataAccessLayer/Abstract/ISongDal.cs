using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.DataAccessLayer.Abstract
{
    public interface ISongDal : IGenericDal<Song>
    {
        //eğer interface varsa mutlaka implement edilmeli

        List<Song> GetSongsWithAlbumAndArtist();
        List<Song> GetSongsByAlbumId(int id);
        List<Song> GetSongswithAlbumByUserID(int id);
        List<Song> GetSongWithAlbum();
    }
}
