using Microsoft.AspNetCore.Mvc;
using PurebaNetCoreApi.Models;
using PurebaNetCoreApi.Repository;
using PurebaNetCoreApi.Response;

namespace PurebaNetCoreApi.Controllers
{
    [ApiController]
	[Route("cliente")]
	public class ClienteController : ControllerBase
	{
		ClienteDB clienteDB = new ClienteDB();


		[HttpGet]
		[Route("List")]
		public List<Cliente> ListClient()
		{
			
			var clientes = clienteDB.Get();

			return clientes;
		}
		[HttpGet]
		[Route("ListByID")]
		public ApiResponse<Cliente> ListClientById(int codigo)
		{
			var clientes = clienteDB.GetById(codigo);


			return new ApiResponse<Cliente>
			{
				Success = true,
				Message = "",
				Result = clientes

			};
		}

		[HttpPost]
		[Route("Save")]
		public ApiResponse<Cliente> SaveClient(Cliente cliente)
		{

			clienteDB.AddCliente(cliente);
			return new ApiResponse<Cliente>
            {
				Success = true,
				Message = "",
				Result = cliente
			};



		}
		[HttpPost]
		[Route("Delete")]
		public ApiResponse<int?> ClientDelete(int _id)
		{


			clienteDB.ClientDelete(_id);
			return new ApiResponse<int?>
            {
				Success = true,
				Message = "",
				Result = _id
			};


		}
		[HttpPost, Route("Update")]
		public dynamic ClientUpdate(Cliente cliente)
		{
			try
			{
				var result = clienteDB.ClientUpdate(cliente);
				return new
				{
					success = true,
					message = "Cliente Modificado",
					result = result
				};

			}
			catch (Exception ex)
			{
				return new
				{
					success = false,
					message = ex.Message,
					result = ""
				};
			}
		}
	}
}
