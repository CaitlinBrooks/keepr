<template>
  <div class="home">
    <h1>Welcome Home</h1>
    {{}}
  </div>
</template>

<script>
  export default {
    name: "home",
    computed() {

    },
    mounted() {
      this.$store.dispatch('getAllKeeps')
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" });
      }
    }
  };
</script>