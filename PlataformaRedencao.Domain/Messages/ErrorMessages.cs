namespace PlataformaRedencao.Domain.Messages
{
    public static class ErrorMessages
    {
        public const string UserNotFoundException = "Usuário ou Senha inválidos";
        public const string MemberAlreadyExists = "Já existe um membro com o CPF fornecido. ";
        public const string ChurchNotFound = "Igreja não encontrada";
        public const string ProfessionalNotFound = "A profissão não foi encontrada";
        public const string ProfessionAlreadyRegistered = "A profissão já foi cadastrada.";
        public const string EntityNotFound = "Classe ou objeto de valor não encontrados.";
        public const string UnauthorizedAccess = "Acesso não autorizado.";
        public const string CpfAlreadyExistsForAnotherMember = "CPF já está registrado para outro membro da igreja";

    }
}