<template>

    <div class="badge text-mono" :class="[props.size, props.type]">
      <slot></slot>
    </div>
    
  </template>
  
  <script setup lang="ts">
      export type BadgeSizeEnum = "small" | "medium" | "large" 
      export type BadgeTypeEnum = "default" | "success";
  
      export type BadgeProperties = {size?: BadgeSizeEnum, type?: BadgeTypeEnum };
      const props = withDefaults(defineProps<BadgeProperties>(), { size: "small", type: "default"});
  </script>
  <style>
  .badge {
    box-sizing: border-box;
    display: flex;
    width: fit-content;
    align-items: center;
    justify-content: center;
    text-align: center;
    background:var(--gray--50);
    border: 1px solid var(--gray--200);
    border-radius: 16px;
    padding: 2px 8px; 
    color: var(--gray--700);
    font-size: 14px;
  }
  
  
  .badge.medium {
    padding: 4px 12px;
  }
  
  .badge.large {
    padding: 6px 16px;
  }
  
  .badge.success {
    background: var(--success--50);
    border: 1px solid var(--success--200);
    color:var(--success--700);
  }
  
  </style>