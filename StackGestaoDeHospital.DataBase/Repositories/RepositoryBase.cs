using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StackGestaoDeHospital.DataBase.Repositories
{
    /// <summary>
    /// Repositório genérico para operações básicas de banco de dados usando Entity Framework.
    /// </summary>
    /// <typeparam name="T">Tipo de entidade que este repositório gerencia.</typeparam>
    public class RepositoryBase<T> where T : class
    {
        protected readonly HospitalDbContext _context;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Inicializa uma nova instância do repositório.
        /// </summary>
        /// <param name="context">O contexto do banco de dados.</param>
        public RepositoryBase(HospitalDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // ===== CRIAR =====

        /// <summary>
        /// Adiciona uma nova entidade ao banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a ser adicionada.</param>
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Adiciona múltiplas entidades ao banco de dados.
        /// </summary>
        /// <param name="entities">Coleção de entidades a serem adicionadas.</param>
        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        // ===== LER =====

        /// <summary>
        /// Retorna todas as entidades do tipo T do banco de dados.
        /// </summary>
        /// <returns>Coleção contendo todas as entidades.</returns>
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// Busca uma entidade pelo ID.
        /// </summary>
        /// <param name="id">O ID da entidade a ser buscada.</param>
        /// <returns>A entidade encontrada ou null se não existir.</returns>
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Busca entidades que atendem ao critério especificado.
        /// </summary>
        /// <param name="predicate">Expressão lambda contendo o critério de busca.</param>
        /// <returns>Coleção de entidades que atendem ao critério.</returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        /// <summary>
        /// Retorna a primeira entidade que atende ao critério especificado.
        /// </summary>
        /// <param name="predicate">Expressão lambda contendo o critério de busca.</param>
        /// <returns>A primeira entidade encontrada ou null se nenhuma atender ao critério.</returns>
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        // ===== ATUALIZAR =====

        /// <summary>
        /// Marca uma entidade para ser atualizada no banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a ser atualizada.</param>
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        /// <summary>
        /// Marca múltiplas entidades para serem atualizadas no banco de dados.
        /// </summary>
        /// <param name="entities">Coleção de entidades a serem atualizadas.</param>
        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        // ===== DELETAR =====

        /// <summary>
        /// Remove uma entidade do banco de dados.
        /// </summary>
        /// <param name="entity">A entidade a ser removida.</param>
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Remove múltiplas entidades do banco de dados.
        /// </summary>
        /// <param name="entities">Coleção de entidades a serem removidas.</param>
        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        // ===== VERIFICAÇÃO =====

        /// <summary>
        /// Verifica se existe alguma entidade que atende ao critério especificado.
        /// </summary>
        /// <param name="predicate">Expressão lambda contendo o critério de busca.</param>
        /// <returns>Verdadeiro se existe alguma entidade que atende ao critério, caso contrário falso.</returns>
        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        /// <summary>
        /// Conta o total de entidades no banco de dados.
        /// </summary>
        /// <returns>O número total de entidades.</returns>
        public int Count()
        {
            return _dbSet.Count();
        }

        // ===== SALVAR =====

        /// <summary>
        /// Persiste todas as alterações pendentes no banco de dados de forma síncrona.
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Persiste todas as alterações pendentes no banco de dados de forma assíncrona.
        /// </summary>
        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
