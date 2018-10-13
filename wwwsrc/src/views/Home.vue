<template>
  <div class="home">
    <h1>Dashboard</h1>
    <UserKeeps></UserKeeps>
    <UserVaults></UserVaults>
    <button @click="logout">Logout</button>
  </div>
</template>

<script>
  import UserKeeps from "../components/UserKeeps.vue"
  import UserVaults from "../components/UserVaults.vue"
  export default {
    //THIS IS THE USER HOMEBASE -- THEIR DASHBOARD
    name: "home",
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    components: {
      UserKeeps,
      UserVaults
    },
    mounted() {
      this.$store.dispatch("getVaultById", this.user.id);
      this.$store.dispatch("getKeepsByUserId", this.user.id);

      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout")
      }
    },
    newKeep() {
      return this.$store.dispatch("newKeep", this.keep);
    }
  };
</script>