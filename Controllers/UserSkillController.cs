﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Web.Http.Cors;
using PrismAPI.DAL;
using PrismAPI.Models;


namespace PrismAPI.UserSkillControllers
{
    public class UserSkillController : ApiController
    {
        // GET: LoginCode
        public Logger Log = null;
        public UserSkillController()
        {
            Log = Logger.GetLogger();
        }

        UserSkillDAL userskillDAL = new UserSkillDAL();

        [HttpGet]
        [ActionName("GetAllUserSkill")]
        public List<UserSkill> GetAllUserSkill()
        {
            Log.writeMessage("UserSkillController GetAllUserSkill Start");
            List<UserSkill> list = null;
            try
            {
                list = userskillDAL.GetAllUserSkill();
            }
            catch (Exception ex)
            {
                Log.writeMessage("UserSkillController GetAllUserSkill Error " + ex.Message);
            }
            Log.writeMessage("UserSkillController GetAllUserSkill End");
            return list;
        }

        [HttpGet]
        [ActionName("GetUserSkillById")]
        public UserSkill GetUserSkillById(int UserSkillId)
        {
            Log.writeMessage("UserSkillController GetUserSkillById Start");
            UserSkill userskill = null;
            try
            {
                userskill = userskillDAL.GetUserSkillById(UserSkillId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("UserSkillController GetUserSkillById Error " + ex.Message);
            }
            Log.writeMessage("UserSkillController GetUserSkillById End");
            return userskill;
        }

        /* [HttpGet]
         [ActionName("GetLoginCodeByEmail")]
         public LoginCode GetLoginCodeByEmail(string Email)
         {
             Log.writeMessage("LoginCodeController GetLoginCodeByEmail Start");
             LoginCode loginCode = null;
             try
             {
                 loginCode = loginCodeDAL.GetLoginCodeByEmail(Email);
             }
             catch (Exception ex)
             {
                 Log.writeMessage("LoginCodeController GetLoginCodeByEmail Error " + ex.Message);
             }
             Log.writeMessage("LoginCodeController GetLoginCodeByEmail End");
             return loginCode;
         }*/

        [HttpPost]
        [ActionName("AddUserSkill")]
        public IHttpActionResult AddUserSkill(UserSkill userskill)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                userskill.CreatedBy = "Admin";
                userskill.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                userskill.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                userskill.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = userskillDAL.AddUserSkill(userskill);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("UserSkillController AddUserSkill Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateUserSkill")]
        public IHttpActionResult UpdateUserSkill(UserSkill userskill)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                userskill.CreatedBy = "Admin";
                userskill.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                userskill.UpdatedBy = "Admin";
                userskill.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = userskillDAL.UpdateUserSkill(userskill);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("UserSkillController AddUserSkill Error " + ex.Message);
            }
            return Ok(result);
        }

        /*
                [HttpGet]
                [ActionName("Login")]
                public Loginc Loginc(string Email, string Password)
                {
                    Log.writeMessage("LoginCodeController GetLoginCodeById Start");
                    Loginc user = null;
                    try
                    {
                        user = loginCodeDAL.Loginc(Email, Password);
                    }
                    catch (Exception ex)
                    {
                        Log.writeMessage("LoginCodeController GetLoginCodeById Error " + ex.Message);
                    }
                    Log.writeMessage("LoginCodeController GetLoginCodeById End");
                    return user;
                }

                [HttpGet]
                [ActionName("OtpNo")]
                public OtpNo OtpNo(string Mobile)
                {
                    Log.writeMessage("LoginCodeController GetLoginCodeById Start");
                    OtpNo OtpNo = null;
                    try
                    {
                        OtpNo = loginCodeDAL.OtpNo(Mobile);
                    }
                    catch (Exception ex)
                    {
                        Log.writeMessage("LoginCodeController GetLoginCodeById Error " + ex.Message);
                    }
                    Log.writeMessage("LoginCodeController GetLoginCodeById End");
                    return OtpNo;
                }*/
        // PUT: api/Address/5
        //[HttpPut]
        //[ActionName("UpdateFirstModel")]
        //public IHttpActionResult UpdateFirstModel(FirstModel firstModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        var result = firstDAL.UpdateFirstModel(firstModel);




        //        if (result == "Success")
        //        {
        //            return Ok("Success");
        //        }
        //        else
        //        {
        //            return Ok("Failed");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage("FirstController UpdateFirstModel Error " + ex.Message);
        //    }
        //    return Ok("Failed");
        //}

        //// DELETE: api/Address/5

        public IHttpActionResult DeleteUserSkill(int Id)
        {
            try
            {
                var result = userskillDAL.DeleteUserSkill(Id);

                if (result == "Success")
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage("UserSkillController DeleteUserSkill Error " + ex.Message);
            }
            return Ok("Failed");
        }


        //[HttpPost]
        //public async Task<IActionResult> SendMail([FromBody] Email email)
        //{
        //    Console.WriteLine("Sending email");
        //    var client = new System.Net.Mail.SmtpClient("smtp.example.com", 111);
        //    client.UseDefaultCredentials = false;
        //    client.EnableSsl = true;
        //    client.Credentials = new System.Net.NetworkCredential(emailid, password);
        //    var mailMessage = new System.Net.Mail.MailMessage();
        //    mailMessage.From = new System.Net.Mail.MailAddress(senderemail);
        //    mailMessage.To.Add(email.To);
        //    mailMessage.Body = email.Text;
        //    await client.SendMailAsync(mailMessage);
        //    return Ok();
        //}


        //[HttpPost]
        //public async Task<IHttpActionResult> SaveProfilePhoto(int Id)
        //{                  
        //    try
        //    {              
        //        if (!Request.Content.IsMimeMultipartContent())
        //            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

        //        var provider = new MultipartMemoryStreamProvider();
        //        await Request.Content.ReadAsMultipartAsync(provider);
        //        foreach (var file in provider.Contents)
        //        {
        //            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
        //            var buffer = await file.ReadAsByteArrayAsync();
        //            string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
        //            //get the folder that's in
        //            string theDirectory = Path.GetDirectoryName(fullPath);
        //            theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));

        //            File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);
        //            //Do whatever you want with filename and its binary data.
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }

        //    return Ok();
        //}

        //[HttpPost]
        //public void SaveProfilePhoto(UserProfilePhoto profile)
        //{
        //    try
        //    {
        //        byte[] imageBytes = Convert.FromBase64String(profile.Photo);
        //        string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
        //        string theDirectory = Path.GetDirectoryName(fullPath);
        //        theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
        //        //string filePath = "http://localhost:62842/ProfilePhoto/";
        //        File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "ProfilePicture_" + profile.Id + ".jpeg", imageBytes);
        //        //File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }
        //}


        /* [HttpPost]
         public async Task<IHttpActionResult> SaveLoginCodeImage(int Id)
         {
             try
             {
                 if (!Request.Content.IsMimeMultipartContent())
                     throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

                 var provider = new MultipartMemoryStreamProvider();
                 await Request.Content.ReadAsMultipartAsync(provider);
                 foreach (var file in provider.Contents)
                 {
                     var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                     var buffer = await file.ReadAsByteArrayAsync();
                     string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                     //get the folder that's in
                     string theDirectory = Path.GetDirectoryName(fullPath);
                     theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
                     File.WriteAllBytes(theDirectory + "/Content/LoginCode" + "/" + Id + "_" + filename, buffer);
                     //Do whatever you want with filename and its binary data.

                     // get existing rocrd
                     var loginCode = loginCodeDAL.GetLoginCodeById(Id);
                     var filenamenew = Id + "_" + filename;
                     if (loginCode.Photo.ToLower() != filenamenew.ToLower())
                     {
                         File.Delete(theDirectory + "/Content/LoginCode" + "/" + loginCode.Photo);
                         loginCode.Photo = Id + "_" + filename;
                         var result = loginCodeDAL.UpdateLoginCode(loginCode);

                     }
                 }
             }
             catch (Exception ex)
             {
                 Log.writeMessage(ex.Message);
             }

             return Ok();*/
    }
}
