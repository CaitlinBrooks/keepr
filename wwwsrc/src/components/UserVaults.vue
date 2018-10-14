<template>
  <div class="userVaults">
    <h1>Your Vaults</h1>
    <!-- <div class="keepCard" v-if="keep.isPrivate == 0"> -->
    <div v-for="vault in vaultsById" :key="vaultsById.id">
      <img :src="keep.img" class="keepCard" alt="vault.name">
      <p>Title: {{vaultsById.name}}</p>
      <button type="submit">Delete Vault</button>
    </div>
  </div>
  </div>
  <!-- reference Vue-Music for this card -->
</template>

<script>
  export default {
    name: "userVaults",
    computed: {
      vaultsById() {
        return this.$store.state.vaults;
      }
    },
    components: {
      // VaultKeeps
    }
  };
</script>

<style>
</style>

<!-- vaultkeeps needs to show in here too -->