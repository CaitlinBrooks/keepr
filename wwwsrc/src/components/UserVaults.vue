<template>
  <div class="userVaults">
    <form @submit.prevent="createNewVault">
      <input type="text" placeholder="Vault Name" v-model="newVault.name" required>
      <input type="text" placeholder="Description" v-model="newVault.description" required>
      <button type="submit">Create Vault</button>
    </form>
    <h1>Your Vaults</h1>
    <!-- <div class="keepCard" v-if="keep.isPrivate == 0"> -->
    <div v-for="vault in vaults" :key="vault.id">
      <router-link :to="{name:'vault', params:{vaultId: vault.Id}}">
        Title: {{Vaults.name}}
      </router-link>
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
      vaults() {
        return this.$store.state.vaults;
      } //getAllVaults?
    },
    components: {

    },
    methods: {
      deleteVault(keep) {
        this.$store.dispatch("deleteVault", vault)
      }
    },
    createNewVault() {
      this.$store.dispatch("newVault", this.newVault)
      this.newVault = { name: "", description: "" }
    }
  }
</script>

<style>
</style>

<!-- vaultkeeps needs to show in here too? -->