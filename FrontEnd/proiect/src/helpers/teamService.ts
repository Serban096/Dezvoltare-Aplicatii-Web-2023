import axios from 'axios'

const axiosInstance = axios.create({
    baseURL: 'https://localhost:7263',
    withCredentials: true
    }
  );

const teamsApi = {
  getAllTeams: async () => {
    try {
      const response = await axios.get(`/api/Team/all`);
      console.log ("aici: " , response.data);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  createTeam: async (team: any) => {
    try {
      const response = await axios.post(`/api/Team/CreateTeam`, team);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  deleteTeam: async (teamId: any) => {
    try {
      const response = await axios.delete(`/api/Team/DeleteTeam`);
      return response.data;
    } catch (error) {
      throw error;
    }
  },

  editTeam: async (team: any) => {
    try {
      const response = await axios.patch(`/api/Team/UpdateTeam`, team);
      return response.data;
    } catch (error) {
      throw error;
    }
  },
};

export default teamsApi;
