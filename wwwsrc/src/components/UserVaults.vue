<template>
  <div class="userVaults">
    <h1>Your Vaults</h1>
    <!-- <div class="keepCard" v-if="keep.isPrivate == 0"> -->
    <div v-for="vault in vaultsById" :key="vaultsById.id">
      <img :src="keep.img" class="keepCard" alt="vault.name">
      <p>Title: {{vaultsById.name}}</p>
      <button @click="deleteVault(vault)">Delete Vault</button>
    </div>
  </div>
  </div>
</template>

<script>
  export default {
    name: "userVaults",
    data() {
      return {
        newVault: {
        }
      }
    },
    created() {
      this.$store.dispatch("getAllVaults")
    },
    computed: {
      vaultsById() {
        return this.$store.state.vaults;
      } //getAllVaults?
    },
    components: {
      // VaultKeeps?
    },
    methods: {
      deleteVault(keep) {
        this.$store.dispatch("deleteVault", vault)
      }
    },
    newVault() {
      this.$store.dispatch("newVault", this.newVault)
    }
  }
</script>

<style>
</style>

<!-- vaultkeeps needs to show in here too -->