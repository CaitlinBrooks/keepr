<template>
  <div class="vaultKeeps">
    <h1>Welcome {{user.username}}!</h1>
  </div>
</template>

<script>
  export default {
    //THIS IS THE USERS DASHBOARD
    name: "vaultKeeps",
    computed: {
      user() {
        return this.$store.state.user;
      },
      components() {
        // keepsById,
        // vaultsById
      },
      mounted() {
        this.$store.dispatch("getVaultsById", this.$store.state.user.id);
        this.$store.dispatch("getKeepsById", this.$store.state.user.id);

        //blocks users not logged in
        if (!this.$store.state.user.id) {
          this.$router.push({ name: "login" });
        }
      }
    }
  };
</script>