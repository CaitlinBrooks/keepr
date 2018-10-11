<template>
  <div class="home">
    <h1>Welcome User!</h1>
  </div>
</template>

<script>
  export default {
    //THIS IS THE USERS DASHBOARD
    name: "home",
    computed: {
      user() {
        return this.$store.state.user;
      },
      components() {
        Keeps // all the keeps regardless of sign-in
      },
      mounted() {
        // this.$store.dispatch("getVaultsById", this.$store.state.user.id);
        // this.$store.dispatch("getKeepsById", this.$store.state.user.id);

        //blocks users not logged in
        if (!this.$store.state.user.id) {
          this.$router.push({ name: "login" });
        }
      }
    }
  };
</script>