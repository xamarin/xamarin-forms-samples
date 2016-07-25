using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoRESTService.Attributes;
using TodoRESTService.Models;
using TodoRESTService.Services;

namespace TodoRESTService.Controllers
{
    public class TodoItemsController : BaseApiController
    {
        static readonly ITodoService todoService = new TodoService(new TodoRepository());

        [HttpGet]
        [BasicAuthentication(RequireSsl = false)]
        public HttpResponseMessage Get()
        {
            return base.BuildSuccessResult(HttpStatusCode.OK, todoService.GetData());
        }

        [HttpPost]
        [BasicAuthentication(RequireSsl = false)]
        public HttpResponseMessage Create(TodoItem item)
        {
            try
            {
                if (item == null ||
                    string.IsNullOrWhiteSpace(item.Name) ||
                    string.IsNullOrWhiteSpace(item.Notes))
                {
                    return base.BuildErrorResult(HttpStatusCode.BadRequest, ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }

                // Determine if the ID already exists
                var itemExists = todoService.DoesItemExist(item.ID);
                if (itemExists)
                {
                    return base.BuildErrorResult(HttpStatusCode.Conflict, ErrorCode.TodoItemIDInUse.ToString());
                }
                todoService.InsertData(item);
            }
            catch (Exception)
            {
                return base.BuildErrorResult(HttpStatusCode.BadRequest, ErrorCode.CouldNotCreateItem.ToString());
            }
        
            return base.BuildSuccessResult(HttpStatusCode.Created);
        }

        [HttpPut]
        [BasicAuthentication(RequireSsl = false)]
        public HttpResponseMessage Edit(string id, TodoItem item)
        {
            try
            {
                if (item == null ||
                    string.IsNullOrWhiteSpace(item.Name) ||
                    string.IsNullOrWhiteSpace(item.Notes))
                {
                    return base.BuildErrorResult(HttpStatusCode.BadRequest, ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }

                var todoItem = todoService.Find(id);
                if (todoItem != null)
                {
                    todoService.UpdateData(item);
                }
                else
                {
                    return base.BuildErrorResult(HttpStatusCode.NotFound, ErrorCode.RecordNotFound.ToString());
                }
            }
            catch (Exception)
            {
                return base.BuildErrorResult(HttpStatusCode.BadRequest, ErrorCode.CouldNotUpdateItem.ToString());
            }

            return base.BuildSuccessResult(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [BasicAuthentication(RequireSsl = false)]
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                var todoItem = todoService.Find(id);
                if (todoItem != null)
                {
                    todoService.DeleteData(id);
                }
                else
                {
                    return base.BuildErrorResult(HttpStatusCode.NotFound, ErrorCode.RecordNotFound.ToString());
                }
            }
            catch (Exception)
            {
                return base.BuildErrorResult(HttpStatusCode.BadRequest, ErrorCode.CouldNotDeleteItem.ToString());
            }

            return base.BuildSuccessResult(HttpStatusCode.NoContent);
        }
    }
}
