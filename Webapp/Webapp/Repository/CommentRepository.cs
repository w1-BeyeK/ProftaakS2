﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapp.Context;
using Webapp.Interfaces;
using Webapp.Models.Data;

namespace Webapp.Repository
{
    public class CommentRepository
    {
        protected readonly ICommentContext context;

        public CommentRepository(ICommentContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Doctor adds a comment
        /// </summary>
        public bool Add(Comment comment, long treatmentId)
        {
            return context.Insert(comment, treatmentId);
        }

        /// <summary>
        /// Get all comments of a treatment
        /// </summary>
        public List<Comment> GetByTreatment(long treatmentId)
        {
            return context.GetByTreatmentId(treatmentId);
        }
    }
}
