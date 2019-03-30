using System;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace LocationDemo.Services
{
    public interface IPageNavigationService
    {
        void PagePushAsync(Page page);

        Task<Page> PagePopAsync();
    }
}
