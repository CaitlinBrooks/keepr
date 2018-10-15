<template>
  <div class="userVaults">
    <form @submit.prevent="createVault">
      <input type="text" placeholder="Vault Name" v-model="newVault.name" required>
      <input type="text" placeholder="Description" v-model="newVault.description" required>
      <button type="submit">Create Vault</button>
    </form>
    <h2>Your Vaults</h2>
    <!-- <div class="keepCard" v-if="keep.isPrivate == 0"> -->
    <div class="vault" v-for="vault in vaults" :key="vault.id">
      {{vault.name}}
      <router-link :to="{name:'vault', params:{vaultId: vault.Id}}">
        Vault Name: {{vault.name}}
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
      },
      createVault() {
        debugger
        this.$store.dispatch("newVault", this.newVault)
        this.newVault = { name: "", description: "" };
      }
    }
  }
</script>

<style>
</style>

<!-- vaultkeeps needs to show in here too? -->