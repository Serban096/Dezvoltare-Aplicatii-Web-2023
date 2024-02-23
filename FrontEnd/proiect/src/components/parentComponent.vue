<template>
  <div>
    <TeamsComponent @teamsFetched="handleTeamsFetched" />
    <p v-if="selectedTeam">Selected Team: {{ selectedTeam.Name }}</p>
  </div>
</template>

<script>
import TeamsComponent from '@/TeamsComponent';

export default {
  components: {
    TeamsComponent,
  },
  data() {
    return {
      selectedTeam: null,
    };
  },
  methods: {
    handleTeamsFetched(teams) {
      if (teams.length > 0) {
        this.selectedTeam = teams[0];
      }
    },
  },
};
</script>

<style>
</style>
