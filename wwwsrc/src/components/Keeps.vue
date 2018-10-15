<template>
  <div class="publicKeeps row">
    <h2>Keeps</h2>
    <form @submit.prevent="createNewKeep">
      <input type="text" placeholder="keep name" v-model="newKeep.name" required>
      <input type="text" placeholder="keep description" v-model="newKeep.description" required>
      <input type="url" placeholder="ImgUrl" v-model="newKeep.img" required>
      <button type="submit">
        Create New Keep
      </button>
    </form>
    <div class="col-12 keeps-view" v-for="keep in keeps" :key="keep.id">
      <!-- <div class="keepCard" v-if="keep.isPrivate == 0"> -->
      <img :src="keep.img" class="keepCard image" alt="keep.name" style="width:200px;height:200px;">
      <p>{{keep.name}}</p>
      <!-- <p>{{keep.description}}</p> -->
      <button class="btn" @click="deleteKeep(keep)">Delete</button>
      <button class="btn" @click="viewKeep(keep)">View</button>
      <button class="btn" @click="shareKeep(keep)">Share</button>
      <!-- Can I use a modal? How? -->
      <p>Views: {{currentKeep.views}}</p>
      <p>Keeps: {{currentKeep.keeps}}</p>
      <p>Shares: {{currentKeep.shares}}</p>
    </div>
  </div>
  </div>
</template>

<script>
  export default {
    name: "keeps",
    data() {
      return {
        newKeep: {
          isPrivate: 0
        },
        currentKeep: {},
        vaultKeep: {}
      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      },
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      deleteKeep(keep) {
        this.$store.dispatch("deleteKeep", keep)
      },
      createNewKeep() {
        this.$store.dispatch("newKeep", this.newKeep)
        this.newKeep = { name: "", description: "", img: "", isPrivate: 0 }
      },
      viewKeep(keep) {
        keep.views++
        this.currentKeep = keep;
        this.$store.dispatch("updateKeep", keep)
      },
      shareKeep(keep) {
        keep.shares++
        this.currentKeep = keep;
        this.$store.dispatch("updateKeep", keep)
      },
      moveKeepToVault() {
        this.vaultKeep.keepId = this.currentKeep.id;
        this.$store.dispatch("moveKeepToVault", { vaultKeep: this.vaultkeep, keep: this.currentKeep })
      }
    }
  };
</script>

<style>
  /* .keeps-view {
    position: relative;
    width: 50%;
  }

  .image {
    opacity: 1;
    display: block;
    width: 200px;
    height: 200px;
    transition: .5s ease;
    backface-visibility: hidden;
  } */
</style>