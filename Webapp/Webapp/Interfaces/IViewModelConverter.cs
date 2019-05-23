using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapp.Interfaces
{
    public interface IViewModelConverter<TModel, TViewModel>
    {
        TViewModel ModelToViewModel(TModel model);
        TModel ViewModelToModel(TViewModel viewModel);

        List<TViewModel> ModelsToViewModel(List<TModel> models);
    }
}
