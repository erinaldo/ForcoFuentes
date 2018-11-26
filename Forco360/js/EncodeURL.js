			
function encodeUrl(url)
{
 	if (url.indexOf("?")>0)
 	{
		encodedParams = "?";
 		parts = url.split("?");
 		params = parts[1].split("&");
 		for(i = 0; i < params.length; i++)
 		{
			if (i > 0)
	 		{
				encodedParams += "&";
			}
			if (params[i].indexOf("=")>0) //Avoid null values
			{
				p = params[i].split("=");
				encodedParams += (p[0] + "=" + escape(encodeURI(p[1])));
			}
			else
			{
				encodedParams += params[i];
			}
		}
		url = parts[0] + encodedParams;
	}
	return url;
}
