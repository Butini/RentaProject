using Microsoft.AspNetCore.Http;
using RentaProject.Application.Service.Contracts;
using RentaProject.Domain.Entities;
using RentaProject.Infrastructure.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Application.Service.Implementation
{
    public class RentaProjectService : IRentaProjectService
    {
        private readonly IRentaProjectRepository _rentaProjectRepository;

        public RentaProjectService(IRentaProjectRepository rentaProjectRepository)
        {
            _rentaProjectRepository = rentaProjectRepository;
        }

        public async Task<String> NewIncomeStatement(IFormFile formFile)
        {
            FilePathEntity pathUploadFile = new FilePathEntity(await _rentaProjectRepository.UploadFile(formFile));
            List<ActionEntity> listAction;
            List<BitcoinEntity> listBitcon;

            (listAction, listBitcon) = _rentaProjectRepository.ReadExcel(pathUploadFile);
            _rentaProjectRepository.DeleteFile(pathUploadFile);

            listAction = ActionResume(listAction);

            return _rentaProjectRepository.NewExcel(listAction, listBitcon, GetFileName(pathUploadFile.Path));
        }

        private string GetFileName(string path)
        {
            return path.Split("\\")[path.Split("\\").Length - 1];
        }

        private List<ActionEntity> ActionResume(List<ActionEntity> listAction)
        {
            List<ActionEntity> resultListAction = new List<ActionEntity>();

            foreach (var actionValue in listAction)
            {
                if (resultListAction.Count == 0) resultListAction.Add(actionValue);
                else
                {
                    bool founded = false;
                    int i = 0;

                    while (i < resultListAction.Count && !founded)
                    {
                        founded = resultListAction[i].Equals(actionValue);
                        if (!founded) i++;
                    }

                    if (founded) resultListAction[i].AddActionProfitFees(actionValue);
                    else resultListAction.Add(actionValue);
                }
            }

            return resultListAction;
        }
    }
}
