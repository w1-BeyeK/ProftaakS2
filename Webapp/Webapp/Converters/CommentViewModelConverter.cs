using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Models.Data;

namespace Webapp.Converters
{
    public class CommentViewModelConverter : IViewModelConverter<Comment, CommentDetailViewModel>
    {
        public List<CommentDetailViewModel> ModelsToViewModel(List<Comment> models)
        {
            throw new NotImplementedException();
        }

        public CommentDetailViewModel ModelToViewModel(Comment model)
        {
            throw new NotImplementedException();
        }

        public Comment ViewModelToModel(CommentDetailViewModel viewModel)
        {
            return new Comment
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Description = viewModel.Description,
                TreatmentId = viewModel.TreatmentId,
            };
        }
    }
}
