<template>
  <div class="home">
    <h1>Dashboard</h1>
    <UserVaults />
    <keeps />
    <button @click="logout">Logout</button>
  </div>
</template>

<script>
  import Keeps from "../components/Keeps.vue"
  import UserVaults from "../components/UserVaults.vue"
  export default {
    //THIS IS THE USER HOMEBASE -- THEIR DASHBOARD
    name: "home",
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout")
      },
      newKeep() {
        return this.$store.dispatch("newKeep", this.keep);
      }
    },
    mounted() {
      this.$store.dispatch("getKeeps", this.user.id);

      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    components: {
      Keeps,
      UserVaults
    },
  };
</script>