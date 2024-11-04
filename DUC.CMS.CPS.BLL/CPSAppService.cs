using System;
using System.Collections.Generic;
using DUC.CMS.CPS.BLL.DTO;
using DUC.CMS.CustomerService.DAL;
using DUC.CMS.CPS.BLL.Mappers;
using DUC.CMS.CustomerService.DAL.Repository;


namespace DUC.CMS.CPS.BLL
{
    public class CPSAppService
    {
        ///F400
        /// <summary>
        /// Search Personalization orders that have a status appointment scheduled and has no rows in printing Queue 
        /// and or have Rows with the Printing status of failed 
        /// </summary>
        /// <returns></returns>
        public List<CustomerCardSearchDTO> SearchCustomerCard(int? personlizationOrderID, DateTime? fromDate, DateTime? toDate, int? cardCenterID, int pageNo, int pageSize, out int p_count)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.SearchCustomerCard(personlizationOrderID, fromDate, toDate, cardCenterID,pageNo,pageSize,out p_count).ToDTOs();
            }
        }

        ///F401
        /// <summary>
        /// Gets all the defined printer names
        /// </summary>
        /// <returns></returns>
        public List<PrinterDTO> GetAllPrinters(int cardCenterID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetAllPrinters(cardCenterID).ToDTOs();
            }
        }

        ///F402
        /// <summary>
        /// Add To Printer Queue will insert Request no., Current Date Time, Printer, Printing Status to “InQueue” 
        /// or “Pending” in a new table “Printer Queue”. 
        /// </summary>
        /// <returns></returns>
        public bool AddToPrinterQueue(int? personalizationOrderID, int? printerID, DateTime? date, int? userID, int? printingStatus)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.AddToPrinterQueue(personalizationOrderID, printerID, date, userID, printingStatus);
            }
        }

        ///F403
        /// <summary>
        /// Get All requests with Printing status “InQueue” in the printer Queue table
        /// </summary>
        /// <returns></returns>
        public List<PrinterQueueDTO> GetAllPrinterQueue(int? cardCenterID, int PageNo, int PageSize, out int pCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetAllPrinterQueue(cardCenterID, PageNo, PageSize,out pCount).ToDTOs();
            }
        }

        ///F404
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool SavePersonalizedInfo(int orderID, string printerStatus, string remarks, string cardSerial, int? printingStatus, int userID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.SavePersonalizedInfo(orderID, printerStatus, remarks, cardSerial, printingStatus, userID);
            }
        }

        ///F406
        /// <summary>
        /// Add the printer to the system
        /// </summary>
        /// <returns></returns>
        public bool AddPrinter(PrinterDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.AddPrinter(dto.ToEntity());
            }
        }

        ///F407
        /// <summary>
        /// Gets all the printer details
        /// </summary>
        /// <returns></returns>
        public PrinterDTO GetAllPrinterDetails(int printerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetAllPrinterDetails(printerID).ToDTO();
            }
        }

        ///F408
        /// <summary>
        /// Updates the printer details
        /// </summary>
        /// <returns></returns>
        public bool UpdatePrinter(PrinterDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.UpdatePrinter(dto.ToEntity());
            }
        }

        ///F409
        /// <summary>
        /// Delete the printer details
        /// </summary>
        /// <returns></returns>
        public bool DeletePrinter(int printerID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.DeletePrinter(printerID);
            }
        }

        ///F410
        /// <summary>
        /// Gets the personalized information of the card
        /// </summary>
        /// <returns></returns>
        public PersonalizedDataDTO GetPersonalizedInfo(string cardSerial)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetPersonalizedInfo(cardSerial).ToDTO();
            }
        }

        ///F411
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool SubmitQCCheckInfo(QualityAssuranceDTO dto)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.SubmitQCCheckInfo(dto.ToEntity());
            }
        }

        ///F412
        /// <summary>
        /// Returns the open shift for the user in the same location.
        /// </summary>
        /// <returns></returns>
        public List<ShiftDTO> GetUserLocationShift(int? userID, int? locationID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetUserLocationShift(userID, locationID).ToDTOs();
            }
        }

        ///F413
        /// <summary>
        /// Close any open shift for the user at that location if any, then start a new shift 
        /// </summary>
        /// <returns></returns>
        public bool StartShift(int? userID, int? locationID, int? shiftTypeID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.StartShift(userID, locationID, shiftTypeID);
            }
        }

        ///F414
        /// <summary>
        /// Get All Active Shift Types Shift 
        /// </summary>
        /// <returns></returns>
        public List<ShiftTypeDTO> GetAllShiftTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetAllShiftTypes().ToDTOs();
            }
        }

        ///F415
        /// <summary>
        /// Search Personalization orders with all related details of the card center
        /// </summary>
        /// <returns></returns>
        public List<PersonalizationOrderSearchDTO> SearchPersonalizationOrders(PersonalizationOrderSearchInputDTO dto,out int rowNum)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.SearchPersonalizationOrders(dto.ToEntity(),out rowNum).ToDTOs();
            }
        }

        ///F416
        /// <summary>
        /// Gets all the defined CardCenter names
        /// </summary>
        /// <returns></returns>
        public List<CardCenterDTO> GetAllCardCenters()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetAllCardCenters().ToDTOs();
            }
        }

        ///F417
        /// <summary>
        /// Gets all the defined Personalization Order Types 
        /// </summary>
        /// <returns></returns>
        public List<PersonalizationOrderTypeDTO> GetAllPersonalizationOrderTypes()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetAllPersonalizationOrderTypes().ToDTOs();
            }
        }

        ///F418
        /// <summary>
        /// Gets all the defined Personalization Order Status
        /// </summary>
        /// <returns></returns>
        public List<PersonalizationOrderStatusDTO> GetAllPersonalizationOrderStatus()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetAllPersonalizationOrderStatus().ToDTOs();
            }
        }

        ///F419
        /// <summary>
        /// Gets all the defined Printing Status names
        /// </summary>
        /// <returns></returns>
        public List<PrintingStatusDTO> GetAllPrintingStatus()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetAllPrintingStatus().ToDTOs();
            }
        }

        ///F420
        /// <summary>
        /// Close any open shift for the user at that location 
        /// </summary>
        /// <returns></returns>
        public bool EndShift(int shiftID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.EndShift(shiftID);
            }
        }

        ///F421
        /// <summary>
        /// Get All requests with Printing status “Fail” in the printer Queue table
        /// </summary>
        /// <returns></returns>
        public List<PrinterQueueDTO> GetAllErrorQueue(int? cardCenterID, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetAllErrorQueue(cardCenterID,pageNo,pageSize,out rowCount).ToDTOs();
            }
        }

        ///F422
        /// <summary>
        /// Get All Reasons that are attached to the “corrupted” inventory unit status
        /// </summary>
        /// <returns></returns>
        public List<InventoryReasonDTO> GetQCFailedInventoryReasons()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetQCFailedInventoryReasons().ToDTOs();
            }
        }

        //423
        public bool IsDefaultPrinterAlreadySet(int CardCentreID)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.IsDefaultPrinterAlreadySet(CardCentreID);
            }
        }

        //F424
        public List<PrinterQueueDTO> GetAllPendingJobs(int? cardCenterID, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetAllPendingJobs(cardCenterID, pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        //425
        public bool UpdatePrinterQueueStatus(int personalizationOrderID, int printerStatusId, string remarks)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.UpdatePrinterQueueStatus(personalizationOrderID, printerStatusId, remarks);
            }
        }

        //F426
        public bool CancelPrintJob(string personalizationOrderIds)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.CancelPrintJob(personalizationOrderIds);
            }
        }

        //F427
        public bool ReprintJob(string personalizationOrderIds)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.ReprintJob(personalizationOrderIds);
            }
        }

        //F428
        public List<PrinterQueueDTO> GetAllResumeJobs(int? cardCenterID, int pageNo, int pageSize, out int rowCount)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetAllResumeJobs(cardCenterID, pageNo, pageSize, out rowCount).ToDTOs();
            }
        }

        public List<LocationDTO> GetAllLocations()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var repository = new CPSRepository(unitOfWork);
                return repository.GetAllLocations().ToDTOs();
            }
        }
    }
}
