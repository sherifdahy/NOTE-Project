import { environment } from '../../environments/environment';

// const API_VERSION = 'v1';
const BASE_URL = `${environment.apiUrl}/api`;

export const API_ENDPOINTS_CONSTS = {
  AUTH: {
    LOGIN: `${BASE_URL}/auth/get-token`,
    REFRESH_TOKEN: `${BASE_URL}/auth/refresh-token`,
    REVOKE: `${BASE_URL}/auth/revoke-refresh-token`,
    REGISTER: `${BASE_URL}/auth/register`,
    LOGOUT: `${BASE_URL}/auth/logout`,
    FORGET_PASSWORD: `${BASE_URL}/auth/forget-password`,
    RESET_PASSWORD: `${BASE_URL}/auth/reset-password`,
    VERIFY_EMAIL: `${BASE_URL}/auth/verify-email`,
    RESEND_VERIFICATION: `${BASE_URL}/auth/resend-verification`,
    CHANGE_PASSWORD: `${BASE_URL}/auth/change-password`,
  },

  USERS: {
    ME: `${BASE_URL}/user/me`,
  },

  ROLES: {
    GET_ALL: `${BASE_URL}/roles`,
    GET: `${BASE_URL}/roles`,
    CREATE: `${BASE_URL}/roles`,
    UPDATE: `${BASE_URL}/roles`,
    TOGGLE_STATUS: `${BASE_URL}/roles`,
  },

  FILES: {
    UPLOAD: `${BASE_URL}/files/upload`,
    DOWNLOAD: (fileId: string) => `${BASE_URL}/files/${fileId}/download`,
    DELETE: (fileId: string) => `${BASE_URL}/files/${fileId}`,
  },
  UNIVERSITYS: {
    GET_ALL: `${BASE_URL}/Universities`,
    GET: `${BASE_URL}/Universities`,
    CREATE: `${BASE_URL}/Universities`,
    UPDATE: `${BASE_URL}/Universities`,
    TOGGLE_STATUS: `${BASE_URL}/Universities`,
  },

  FACULITIES: {
    GET: `${BASE_URL}/Faculities`,
    CREATE: `${BASE_URL}/Faculities`,
    UPDATE: `${BASE_URL}/Faculities`,
    TOGGLE_STATUS: `${BASE_URL}/Faculities`,
  },
};
