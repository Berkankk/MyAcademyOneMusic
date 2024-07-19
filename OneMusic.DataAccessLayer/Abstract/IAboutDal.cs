using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.DataAccessLayer.Abstract
{
    public interface IAboutDal : IGenericDal<About>
    {
        //interfacei yazdıysak mutlaka implement edilen sınıf olmalıdır
        // T yerine About geliyor yani GenericRepositorydeki (IGenericDal'dan miras alıyordu) tüm metotlarda T yerine About sınıfı geçiyormuş gibi işlem yapacak, diğer classlar içinde durum böyle. Miras almanın önemi burda belirtilmiştir.
    }
}
