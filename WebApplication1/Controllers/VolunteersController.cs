using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volunteeres.Models;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersController : ControllerBase
    {
        public static List<Volunteer> VOLUNTEERS = new List<Volunteer>() {
            new Volunteer{ id=1, firstName="Dan",  lastName="Levi",active = false,days=new List<bool>{true,true,true,true,true,true,true}
    
    },
            new Volunteer{ id=2, firstName="Avi",lastName="Coen", active = false ,days=new List<bool>{true,false,false,false,false,false,false}
     },
            new Volunteer{ id=3, firstName="Hadas",lastName="Katz", active=false ,days=new List<bool>{false,false,false,false,false,false,false}
     },
            new Volunteer{ id=4, firstName="Tova",lastName="lev", active=false ,days=new List<bool>{false,false,false,false,false,false,false}
     },
            new Volunteer{ id=5, firstName="Sara", lastName="Adler",active=false ,days=new List<bool>{false,false,false,false,false,false,false}
    },
            new Volunteer{ id=6, firstName="Miriam",lastName="Ben Lulu", active=false ,days=new List<bool>{false,false,false,false,false,false,false}
     },
        };
        public static List<Volunteer> SCHEDULE=new List<Volunteer>();
        [HttpGet]
       
        public List<Volunteer> Get()
        {
            return VOLUNTEERS;
        }
        [HttpGet]
        [Route("GetSchedule")]
        public List<Volunteer> GetSchedule()
        {
            return SCHEDULE;
        }
        [HttpGet]
        [Route ("GetByID")]
        public Volunteer GetById(int id)
        {
              
            return VOLUNTEERS.Find(x => x.id==id);
          
        }
        //הפונקציה מחזירה את כל המתנדבים הפונטציילים ליום הנוכחי

        [HttpGet]
        [Route("GetByDay")]
        public List<Volunteer> GetByDay(int day)
        {
            return VOLUNTEERS.FindAll(x => x.days[day]==true).ToList();
        }


        [HttpPut]
        [Route("SaveUpdate")]
        public bool SaveUpdate(Volunteer toSave)
        {
            for(int i=0;i<VOLUNTEERS.Count;i++)
            {
                if (VOLUNTEERS[i].id == toSave.id) { //האדם זהה
                        for(int j=0;j< 7; j++)//תעבור על מערך הימים
                        {
                            if (VOLUNTEERS[i].days[j] == true && toSave.days[j] == false)//באם היום הוגדר כאופציה ועכשיו לא
                        {
                            if(SCHEDULE.Count>j)//אין צורך לערוך בדיקה אם קיים במקרה שהמערך
                                //שנשמר קטן מהיום שנבדק או אם הערך שם שווה לריק
                                   if (toSave.id == SCHEDULE[j].id)//תבדוק האם הוא נשמר תחת אות יום
                                
                                        return false;
                        }

                                
                        }
                    VOLUNTEERS[i] = toSave;}
            
            }    return true;
        }
        [HttpPut]
        [Route("SaveSchedule")]
        public void SaveSchedule(List<Volunteer> placedVolunteer)
        {
            //if (placedVolunteer.Count < 7)
            //{

            //}
            SCHEDULE = placedVolunteer;
        }
    }

}
