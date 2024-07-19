using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.Abstract
{
    public interface ISongService : IGenericService<Song>
    {
        List<Song> TGetSongsWithAlbumAndArtist();

        List<Song> TGetSongswithAlbumByUserID(int id);

        List<Song> TGetSongsByAlbumId(int id);
        List<Song> TGetSongWithAlbum();
    }
}
