<template>
    <div>
      <h2>Login</h2>
      <form @submit.prevent="handleLogin">
        <div>
          <label>Username:</label>
          <input v-model="username" type="text" required />
        </div>
  
        <div>
          <label>Password:</label>
          <input v-model="password" type="password" required />
        </div>
  
        <div>
          <button type="submit">Login</button>
        </div>
      </form>
  
      <div v-if="loginResult">
        <h3>Login Result:</h3>
        <pre>{{ loginResult }}</pre>
      </div>
  
      <div v-if="loginError">
        <h3>Login Error:</h3>
        <pre>{{ loginError }}</pre>
      </div>
    </div>
  </template>
  
  <script>
  import { loginUser } from '@/helpers/axios';

  export default {
    data() {
      return {
        username: '',
        password: '',
        loginResult: null,
        loginError: null,
      };
    },
    methods: {
      async handleLogin() {
        try {
          this.loginResult = await loginUser(this.username, this.password);
        } catch (error) {
          this.loginError = error.message || 'An error occurred during login.';
        }
      },
    },
  };
  </script>
  
  <style scoped>
  form {
    max-width: 300px;
    margin: auto;
  }
  
  label {
    display: block;
    margin-bottom: 5px;
  }
  
  input {
    width: 100%;
    margin-bottom: 10px;
  }
  
  button {
    background-color: #4caf50;
    color: white;
    padding: 10px 15px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
  }
  </style>
  