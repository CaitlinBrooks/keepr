<template>
  <div class="home">
    <h1>Welcome User!</h1>
  </div>
</template>

<script>
  export default {
    name: "home",
    computed: {
      user() {
        return this.$store.state.user;
      },
      components() {
        getAllKeeps // review this
        getVaultsById
      },
      mounted() {
        this.$store.dispatch("getVaultsById", this.$store.state.user.id); // need this to be created in the store
        this.$store.dispatch("getKeepsById", this.$store.state.user.id); // need this to be created in the store
        this.$store.dispatch("getAllKeeps", this.$store.state.user.id);

        //blocks users not logged in
        if (!this.$store.state.user.id) {
          this.$router.push({ name: "login" });
        }
      }
    }
  };
</script>