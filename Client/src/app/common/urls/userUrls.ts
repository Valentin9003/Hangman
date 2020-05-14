import { environment } from 'src/environments/environment';

export const userUrls = {
     changePasswordUrl: environment.apiUrl + environment.userInfoUrls.changePassword,
     changeUsernameUrl: environment.apiUrl + environment.userInfoUrls.changeEmail,
     getEmailUrl: environment.apiUrl + environment.userInfoUrls.getEmail
}