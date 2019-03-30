using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LocationDemo.Services
{
    public class PageNavigationService : IPageNavigationService
    {
        public void PagePushAsync(Page page)
        {
            //Navigation.PushAsync(page);
            throw new NotImplementedException();
        }

        public Task<Page> PagePopAsync()
        {
            throw new NotImplementedException();
        }
    }
}
