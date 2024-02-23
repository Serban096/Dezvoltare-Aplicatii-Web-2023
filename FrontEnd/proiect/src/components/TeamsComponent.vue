<template>
    <div>
      <button @click="fetchTeams">Fetch Teams</button>
      <div v-if="teams.length">
        <h2>Teams:</h2>
        <ul>
          <li v-for="team in teams" :key="team.Id">{{ team.Name }}</li>
        </ul>
      </div>
      <div v-else>
        <p>No teams available.</p>
      </div>
    </div>
  </template>
  
  <script>
  import teamsApi from '@/helpers/teamService';
  
  export default {
    data() {
      return {
        teams: [],
      };
    },
    methods: {
      async fetchTeams() {
        try {
          this.teams = await teamsApi.getAllTeams();
          console.log('Fetched Teams:', this.teams);
  
          this.$emit('teamsFetched', this.teams);

        } catch (error) {
          console.error('Error fetching teams:', error);
        }
      },
    },
  };
  </script>
  
  <style>

  </style>
  