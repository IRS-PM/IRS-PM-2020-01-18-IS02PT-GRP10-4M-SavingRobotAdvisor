// using SavingRobotAdvisorApi.Common;

// namespace SavingRobotAdvisorApi.Models
// {
//     public class BankInfo{
//         public Bank BankName {set; get;}
//         public SavingAccountType SavingAccountType {          
//             get
//             {
//                 switch(BankName)
//                 {
//                     case Bank.UOB:
//                         return SavingAccountType.UOBONE;
//                     case Bank.OCBC:
//                         return SavingAccountType.OCBC360;
//                     case Bank.DBS:
//                         return SavingAccountType.Multiplier;
//                     case Bank.SC:
//                         return SavingAccountType.SCBonusSaver;
//                     case Bank.BOC:
//                         return SavingAccountType.BOCSmartSaver;
//                     case Bank.Maybank:
//                         return SavingAccountType.MaybankSaveUp;
//                     case Bank.Citibank:
//                         return SavingAccountType.CitiMaxiGain;
//                     case Bank.CIMB:
//                         return SavingAccountType.CIMBFastSaver;
//                     default:
//                         return SavingAccountType.Unkonwn;
//                 }
//             }
//         }
//         public CreditCardType CreditCardType
//         {
//             get
//             {
//                 switch(BankName)
//                 {
//                     case Bank.UOB:
//                         return CreditCardType.UOBONE;
//                     case Bank.OCBC:
//                         return CreditCardType.OCBC365;
//                     case Bank.DBS:
//                         return CreditCardType.POSBEveryday;
//                     case Bank.SC:
//                         return CreditCardType.SCUnlimitedCashback;
//                     case Bank.BOC:
//                         return CreditCardType.BOCFamily;
//                     case Bank.Maybank:
//                         return CreditCardType.MaybankFamilyAndFriends;
//                     case Bank.Citibank:
//                         return CreditCardType.CitiCashback;
//                     case Bank.CIMB:
//                         return CreditCardType.CIMBSignature;
//                     default:
//                         return CreditCardType.Unkonwn;
//                 }
//             }
//         }
//     }
// }