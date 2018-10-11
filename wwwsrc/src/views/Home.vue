<template>
  <div class="home">
    <h1>Dashboard</h1>
    <getKeepById></getKeepById>
    <getVaultById></getVaultById>
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
      },
      components() {
        getKeepById
        getVaultById
      },
      mounted() {
        this.$store.dispatch("getVaultById");
        this.$store.dispatch("getKeepsById");

        //blocks users not logged in
        if (!this.$store.state.user.id) {
          this.$router.push({ name: "login" });
        }
      }
    }
  };
</script>