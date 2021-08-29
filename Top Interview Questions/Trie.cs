using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    public class Trie
    {

        // R links to node children
        private Trie[] links;

        private  int R = 26;

        public bool isEndFlag;

        public bool containsKey(char ch)
        {
            return links[ch - 'a'] != null;
        }
        public Trie get(char ch)
        {
            return links[ch - 'a'];
        }
        public void put(char ch, Trie node)
        {
            links[ch - 'a'] = node;
        }

        public void setEnd()
        {
            isEndFlag = true;
        }
        public bool isEnd()
        {
            return isEndFlag;
        }
        private Trie root;

        /** Initialize your data structure here. */
        public Trie()
        {
            links = new Trie[R];
            root = new Trie();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            Trie node = root;
            for (int i = 0; i < word.Length; i++)
            {
                
                if(!node.containsKey(word[i]))
                {
                    node.put(word[i], node);
                }

                node = node.get(word[i]);
            }

            node.setEnd();
    }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var node = searchPrefix(word);
            return node != null && node.isEnd();
        }


        public Trie searchPrefix(string prefix)
        {
            Trie node = root;
            for (var i = 0; i < prefix.Length; i++)
            {
                if (!node.containsKey(prefix[i]))
                {
                    return null;
                }
                node = node.get(prefix[i]);
            }

            return node;
        }
        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var node = searchPrefix(prefix);
            return node == null;
        }
    }
}
