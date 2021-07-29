using FluentValidation.Results;
using ProJur.Core.Data;
using System.Threading.Tasks;

namespace ProJur.Core.Messages
{
	public abstract class CommandHandler
	{
		protected ValidationResult ValidationResult;

		protected CommandHandler()
		{
			ValidationResult = new ValidationResult();
		}

		protected void AdicionarErro(string message)
		{
			ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
		}

		protected async Task<ValidationResult> PersistirDados(IUnitOfWork unitOfWork)
		{
			if (!await unitOfWork.Commit()) AdicionarErro("Houve um erro ao persistir os dados");

			return ValidationResult;
		}
	}
}
