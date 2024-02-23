import axios from 'axios'


const axiosInstance = axios.create({
  baseURL: 'https://localhost:7263',
  withCredentials: true
  }
);


export const loginUser = async (Username: string, Password: string) => {
  try {
    const response = await axios.post('/api/User/login', {
      Username,
      Password
    });
    return response.data;
  } 
  catch (error) {
    throw error;
  }
};

export const registerUser = async (FirstName: string, LastName: string, Username: string, Password: string, Email: string) => {
  try {
    const response = await axios.post('/api/User/register', {
      FirstName,
      LastName,
      Username,
      Password,
      Email
    });
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const logoutUser = async () => {
  try {
    const response = await axios.post('/api/User/logout');
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const getById = async (Id : string) => {
  try {
    const response = await axios.get('/api/User/get-by-id');
    return response.data;
  } catch (error) {
    throw error;
  }
};

export const getByUsername = async (Username: string) => {
  try {
    const response = await axios.post('/api/User/get-by-username');
    return response.data;
  } catch (error) {
    throw error;
  }
};



