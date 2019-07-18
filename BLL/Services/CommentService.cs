using ASP_MVC_HW2_Comment.DAL.EF.Contexts;
using ASP_MVC_HW2_Comment.DAL.Models;
using ASP_MVC_HW2_Comment.Models;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentService : IDataBaseService<CommentDTO>
    {
        IUnitOfWork<PokemonContext> UnitOfWork { get; set; }
        public CommentService(IUnitOfWorkService unitOfWorkService)
        {
            UnitOfWork = unitOfWorkService.GetIUnitOfWorkPokemonContext;
        }

        public void Add(CommentDTO commentDTO, string userId)
        {
            commentDTO.UserProfileDTO.Id = userId;
            Comment comment = Mapper.Map<CommentDTO, Comment>(commentDTO);
            comment.UserProfile = null;
            UnitOfWork.Comments.Add(comment);
            UnitOfWork.SaveChanges();
        }

        public async Task<CommentDTO> UpdateAsync(CommentDTO commentDTO)
        {
            Comment comment = await UnitOfWork.Comments.GetAsync(i => i.Id == commentDTO.Id);
            if (comment != null)
            {
                Mapper.Map(commentDTO, comment);
                UnitOfWork.Comments.Update(comment);
                await UnitOfWork.SaveChangesAsync();
                comment = await UnitOfWork.Comments.GetAsync(i => i.Id == commentDTO.Id);
                if (comment != null)
                    return Mapper.Map<Comment, CommentDTO>(comment);
                else
                    return null;
            }
            else
                return null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Comment comment = await UnitOfWork.Comments.GetAsync(i => i.Id == id);
            if (comment != null)
            {
                UnitOfWork.Comments.Delete(comment);
                await UnitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
        public async Task<ICollection<CommentDTO>> GetAllAsync()
        {
            ICollection<CommentDTO> commentDTOs =
                Mapper.Map<ICollection<Comment>, List<CommentDTO>>(await UnitOfWork.Comments.GetAllAsync());
            if (commentDTOs.Count != 0)
                return commentDTOs;
            else
                return null;
        }
        public async Task<CommentDTO> FindAsync(int id)
        {
            CommentDTO commentDTO =
                Mapper.Map<Comment, CommentDTO>(await UnitOfWork.Comments.FindAsync(c=>c.Id == id));
            if (commentDTO != null)
                return commentDTO;
            else
                return null;
        }
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
