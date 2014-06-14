using Treb.Entities.Enums;
using Treb.Mvc.Uipc.ViewModels;

namespace Treb.Mvc.Uipc
{
    public static partial class ViewModelProvider
    {
        public static BaseSearchViewModel GetSearchViewModel()
        {
            //TODO: Replace fake logic
            var model = new BaseSearchViewModel();
            model.SearchBarViewModel = new SearchBarViewModel();
            model.SearchBarViewModel.Baths = new[]
                                             {
                                                 1, 2, 3, 4, 5
                                             };
            model.SearchBarViewModel.BedRooms = new[]
                                                {
                                                    1, 2, 3, 4, 5
                                                };
            model.SearchBarViewModel.Countries = new[]
                                                 {
                                                     new CountrySearchViewModel
                                                     {
                                                         Name = "USA"
                                                     },
                                                     new CountrySearchViewModel
                                                     {
                                                         Name = "Canada"
                                                     }
                                                 };
            model.SearchBarViewModel.RenderType = SearchBarRenderType.Full;
            return model;
        }
    }
}