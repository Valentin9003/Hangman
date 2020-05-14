import { environment } from 'src/environments/environment';

export const authUrls = {   
   loginPath: environment.apiUrl + environment.authUrls.login,
   registerPath: environment.apiUrl + environment.authUrls.register,
   getUsernamePath: environment.apiUrl + environment.authUrls.getUsername
  
}