export interface AuthResponse {
  id : number;
  email : string;
  name : string;
  token: string;
  expiresIn: number;
  refreshToken: string;
  refreshTokenExpiration : Date;
}
