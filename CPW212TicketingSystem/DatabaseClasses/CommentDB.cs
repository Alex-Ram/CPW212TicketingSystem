using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPW212TicketingSystem
{
    static class CommentDB
    {

        static TicketingSystemDBContext db = new TicketingSystemDBContext();

        // Creates a comment and adds it to the database.
        public static void addComment(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
        }
        // removes a comment ..Though there should never be a reason to remove a comment really.
        public static void DeleteComment(Comment comment)
        {
            Comment commentToUpdate = db.Comments.Find(comment.CommentID);
            db.Comments.Remove(commentToUpdate);
            db.SaveChanges();
        }

        public static void UpdateComment(Comment comment)
        {
            Comment commentToUpdate = db.Comments.Find(comment.CommentID);
            commentToUpdate.Text = comment.Text;
            commentToUpdate.LastEdited = DateTime.Now;

            db.SaveChanges();
        }

        public static List<Comment> GetAllComments()
        {
            List<Comment> ListOfComments = (db.Comments).ToList();
            return ListOfComments;
        }

        public static List<Comment> GetCommentsByTickID(Ticket ticket)
        {
            List<Comment> TicketComments = db.Comments.Where(c => c.Ticket.TicketID == ticket.TicketID).ToList();

            return TicketComments;

        }

    }
}
