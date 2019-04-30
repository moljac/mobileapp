using Toggl.Core.UI.Services;

namespace Toggl.Core.UI.ViewModels
{
    public static class ViewModelExtensions
    {
        public static IDialogService SelectDialogService(this IViewModel viewModel,
            IDialogService injectedDialogService)
        {
            return viewModel.View ?? injectedDialogService;
        }
    }
}