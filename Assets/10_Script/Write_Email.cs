using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class Write_Email : MonoBehaviour 
{
	public string mailSubject =  "Golden Club";
	private string message;
	public string email_from;
	public string password;
	public string email_to;

	public UILabel message_box;
	public GameObject email_reward_popUp;
	private string emailReward;

	public void Email_Us ()
	{
		message = message_box.text;
		MailMessage mail = new MailMessage();
		
		mail.From = new MailAddress(email_from);
		mail.To.Add(email_to);
		mail.Subject = mailSubject;
		mail.Body = message;
		
		SmtpClient smtpServer = new SmtpClient("smtp.websupport.sk");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential(email_from, password) as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback = 
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
		{ return true; };
		smtpServer.Send(mail);
		Debug.Log("success");
		CheckEmailEntitlement();
	}

	public void CheckEmailEntitlement()
	{
		emailReward = PlayerPrefs.GetString ("Email", "not awarded");
		if (emailReward == "not awarded") 
		{
			if(email_reward_popUp != null)
			{
				email_reward_popUp.SetActive(true);
			}
		} 
		else if (emailReward == "awarded")
		{
			Debug.Log ("UNFORTUNATELLY YOU HAVE BEEN ALREADY AWARDED");
		}
	}
}
